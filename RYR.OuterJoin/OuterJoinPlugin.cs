using System.Security.Cryptography.X509Certificates;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;
using System.Text;

namespace RYR.OuterJoin
{
    public class OuterJoinPlugin : Plugin
    {
        public OuterJoinPlugin()
            : base(typeof(OuterJoinPlugin))
        {
            base.RegisteredEvents.Add(new Tuple<int, string, string, Action<LocalPluginContext>>(
                (int)LocalPluginContext.PipelinePhase.PreOperation,
                LocalPluginContext.Message.RetrieveMultiple.ToString(),
                null, Execute));
        }

        protected void Execute(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new ArgumentNullException("localContext");
            }
            if (!localContext.PluginExecutionContext.InputParameters.ContainsKey("Query")) return;

            var query = localContext.PluginExecutionContext.InputParameters["Query"] as QueryExpression;
            if (query != null)
            {
                foreach (var linkedEntity in query.LinkEntities)
                {
                    var linkPrimaryKey = linkedEntity.LinkToEntityName + "id";
                    if (linkedEntity.LinkCriteria.Conditions
                        .Any(x => x.AttributeName
                            .Equals(linkPrimaryKey, StringComparison.CurrentCultureIgnoreCase)
                            && x.Operator == ConditionOperator.Null))
                    {
                        query.Criteria.AddCondition(linkedEntity.LinkToEntityName, linkPrimaryKey, ConditionOperator.Null);
                        linkedEntity.JoinOperator = JoinOperator.LeftOuter;
                        linkedEntity.LinkCriteria.Conditions.Clear();
                    }
                } 
            }
        }
    }
}
