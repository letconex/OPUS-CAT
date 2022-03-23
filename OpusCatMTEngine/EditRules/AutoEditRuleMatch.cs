﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpusCatMTEngine
{
    public class AutoEditRuleMatch
    {
        public AutoEditRuleMatch(AutoEditRule rule, Match match, int matchIndex)
        {
            this.Rule = rule;
            this.Match = match;
            this.MatchIndex = matchIndex;
        }

        public AutoEditRule Rule { get; }
        public Match Match { get; }
        public int MatchIndex { get; }
    }
}
