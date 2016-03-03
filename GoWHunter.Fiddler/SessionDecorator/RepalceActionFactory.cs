using System;
using Fiddler;

namespace GoWHunter.Fiddler.SessionDecorator
{
    public static class RepalceActionFactory
    {
        public static Func<Session, string,string, bool> GetReplaceAction(ReplaceAction action)
        {
            var methodName = "util" + action;
            Func<Session, string, string, bool> result = (s,key,value) =>
            {
                switch (action)
                {
                    case ReplaceAction.ReplaceInRequest:
                        return s.utilReplaceInRequest(key, value);
                    case ReplaceAction.ReplaceTagsInRequest:
                        return s.utilReplaceInRequest(BuildKey(key), value);
                    case ReplaceAction.ReplaceInResponse:
                        return s.utilReplaceInResponse(key, value);
                    case ReplaceAction.ReplaceOnceInResponse:
                        return s.utilReplaceOnceInResponse(key, value, false);
                    case ReplaceAction.ReplaceRegexInResponse:
                        return s.utilReplaceRegexInResponse(key, value);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(action), action, null);
                }
            };
            return result;

        }
        private static string BuildKey(string rawKey)
        {
            return string.Format("__[{0}]__", rawKey);
        }


    }
}