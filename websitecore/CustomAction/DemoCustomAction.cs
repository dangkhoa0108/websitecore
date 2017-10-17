using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.WFFM.Abstractions.Actions;

namespace websitecore.CustomAction
{
    public class DemoCustomAction:ISaveAction
    {
        public ActionState QueryState(ActionQueryContext queryContext)
        {
            return ActionState.Enabled;
        }

        public ID ActionID { get; set; }
        public string UniqueKey { get; set; }
        public ActionType ActionType { get; }

        public void Execute(ID formId, AdaptedResultList adaptedFields, ActionCallContext actionCallContext = null,
            params object[] data)
        {
            var email = adaptedFields.GetEntryByName("Email").Value;
            var password = adaptedFields.GetEntryByName("Password").Value;
            var phone = adaptedFields.GetEntryByName("Phone").Value;
        }
    }
}