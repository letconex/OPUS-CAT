﻿using OpusMTInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;

namespace FiskmoTranslationProvider
{
    
    internal class FiskmöMTServiceHelper
    {
        private static Random rng = new Random();
        private static DateTime TokenCodeExpires = DateTime.MinValue;
        private static string TokenCode;

        public static IMTService getNewProxy(string host, string port)
        {
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;

            var epAddr = new EndpointAddress($"net.tcp://{host}:{port}/MTService");
            var proxy = ChannelFactory<IMTService>.CreateChannel(myBinding, epAddr);
            return proxy;
        }

        /// <summary>
        /// Gets the valid token code.
        /// </summary>
        /// <returns>The token code.</returns>
        /// 

        public static string GetTokenCode(string host, string mtServicePort)
        {
            if (TokenCodeExpires < DateTime.Now)
            {
                // refresh the token code
                // Always dispose allocated resources
                var proxy = getNewProxy(host, mtServicePort);
                try
                {
                    using (proxy as IDisposable)
                    {
                        TokenCode = proxy.Login("user", "user");
                        TokenCodeExpires = DateTime.Now.AddMinutes(1);
                    }
                }
                catch (Exception ex) when (ex is EndpointNotFoundException || ex is CommunicationObjectFaultedException)
                {
                    MessageBox.Show(
                        "No connection to Fiskmö MT service. Check that the MT service is running and that both plugin and MT service use same port numbers.");
                    throw ex;
                }
            }

            return TokenCode;
        }

        public static List<string> GetLanguagePairModelTags(FiskmoOptions options, string languagePair)
        {
            var proxy = getNewProxy(options.mtServiceAddress, options.mtServicePort);
            using (proxy as IDisposable)
            {
                List<string> modelTags = proxy.GetLanguagePairModelTags(GetTokenCode(options), languagePair);
                return modelTags;
            }
        }

        public static string GetTokenCode(FiskmoOptions options)
        {
            return FiskmöMTServiceHelper.GetTokenCode(options.mtServiceAddress, options.mtServicePort);
        }

        /// <summary>
        /// Calls the web service's login method.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns>The token code.</returns>
        public static string Login(string host, string userName, string password, string port)
        {
            // Always dispose allocated resources
            var proxy = getNewProxy(host, port);
            using (proxy as IDisposable)
            {
                return proxy.Login(userName, password);
            }
        }
        
        
        public static List<string> ListSupportedLanguages(FiskmoOptions options)
        {
            return ListSupportedLanguages(GetTokenCode(options),options.mtServiceAddress, options.mtServicePort);
        }

        /// <summary>
        /// Lists the supported languages of the dummy MT service.
        /// </summary>
        /// <param name="tokenCode">The token code.</param>
        /// <returns>The list of the supported languages.</returns>
        public static List<string> ListSupportedLanguages(string tokenCode, string host, string port)
        {
            // Always dispose allocated resources
            var proxy = getNewProxy(host, port);
            using (proxy as IDisposable)
            {
                string[] supportedLanguages = proxy.ListSupportedLanguagePairs(tokenCode).ToArray();
                return supportedLanguages.ToList();
            }
        }

        /// <summary>
        /// Translates a single string with the help of the dummy MT service.
        /// </summary>
        /// <param name="tokenCode">The token code.</param>
        /// <param name="input">The string to translate.</param>
        /// <param name="srcLangCode">The source language code.</param>
        /// <param name="trgLangCode">The target language code.</param>
        /// <returns>The translated string.</returns>
        public static string Translate(FiskmoOptions options, string input, string srcLangCode, string trgLangCode, string modelTag)
        {
            // Always dispose allocated resources
            var proxy = getNewProxy(options.mtServiceAddress, options.mtServicePort);
            using (proxy as IDisposable)
            {
                string result = proxy.Translate(GetTokenCode(options), input, srcLangCode, trgLangCode, modelTag);
                return result;
            }
        }

        internal static void PreTranslateBatch(string host, string mtServicePort, List<string> projectNewSegments, string sourceCode, string targetCode, string modelTag)
        {
            var proxy = getNewProxy(host, mtServicePort);

            using (proxy as IDisposable)
            {
                proxy.PreTranslateBatch(GetTokenCode(host, mtServicePort), projectNewSegments, sourceCode, targetCode, modelTag);
            }
        }

        /// <summary>
        /// Translates multiple strings with the help of the dummy MT service.
        /// </summary>
        /// <param name="tokenCode">The token code.</param>
        /// <param name="input">The strings to translate.</param>
        /// <param name="srcLangCode">The source language code.</param>
        /// <param name="trgLangCode">The target language code.</param>
        /// <returns>The translated strings.</returns>
        public static List<string> BatchTranslate(FiskmoOptions options, List<string> input, string srcLangCode, string trgLangCode, string modelTag)
        {
            // Always dispose allocated resources
            var proxy = getNewProxy(options.mtServiceAddress,options.mtServicePort);
            using (proxy as IDisposable)
            {
                string[] result = proxy.BatchTranslate(GetTokenCode(options), input, srcLangCode, trgLangCode,modelTag).ToArray();
                return result.ToList();
            }
        }

        /// <summary>
        /// Stores a single string pair as translation with the help of the dummy MT service.
        /// </summary>
        /// <param name="tokenCode">The token code.</param>
        /// <param name="source">The source string.</param>
        /// <param name="target">The target string.</param>
        /// <param name="srcLangCode">The source language code.</param>
        /// <param name="trgLangCode">The target language code.</param>
        public static void StoreTranslation(FiskmoOptions options, string source, string target, string srcLangCode, string trgLangCode)
        {
            // Always dispose allocated resources
            var proxy = getNewProxy(options.mtServiceAddress, options.mtServicePort);
            using (proxy as IDisposable)
            {
                proxy.StoreTranslation(GetTokenCode(options), source, target, srcLangCode, trgLangCode);
            }
        }

        internal static void Customize(string host, string mtServicePort, List<Tuple<string, string>> projectTranslations, List<string> uniqueNewSegments, string sourceCode, string targetCode, string modelTag)
        {
            var proxy = getNewProxy(host, mtServicePort);

            //Pick out 200 sentence pairs randomly to use as tuning set
            var randomTranslations = projectTranslations.OrderBy(x => rng.Next());
            var trainingSet = projectTranslations.Skip(200).ToList();
            var validSet = projectTranslations.Take(200).ToList();

            using (proxy as IDisposable)
            {
                proxy.Customize(GetTokenCode(host,mtServicePort), trainingSet, validSet, uniqueNewSegments, sourceCode, targetCode, modelTag);
            }
        }
        
        /// <summary>
        /// Stores multiple string pairs as translation with the help of the dummy MT service.
        /// </summary>
        /// <param name="tokenCode">The token code.</param>
        /// <param name="sources">The source strings.</param>
        /// <param name="targets">The target strings.</param>
        /// <param name="srcLangCode">The source language code.</param>
        /// <param name="trgLangCode">The target language code.</param>
        /// <returns>The indices of the translation units that were succesfully stored.</returns>
        public static int[] BatchStoreTranslation(FiskmoOptions options, List<string> sources, List<string> targets, string srcLangCode, string trgLangCode)
        {
            // Always dispose allocated resources
            var proxy = getNewProxy(options.mtServiceAddress, options.mtServicePort);
            using (proxy as IDisposable)
            {
                return proxy.BatchStoreTranslation(GetTokenCode(options), sources, targets, srcLangCode, trgLangCode);
            }
        }
    }
}
