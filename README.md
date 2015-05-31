CRM2015 doesn't allow outer join queries from the interface. This plugin fixes that behavior i.e. This is how it should be been OOB. The plugin runs on RetrieveMultiple

Basically the plugin enables you to do advanced find queries like this
![AdvancedFind](https://raw.githubusercontent.com/rajyraman/AdvancedQueryOuterJoin/master/OuterJoin.png)

The about query retrieves account that have child contacts, but don't have any opportunities.

This is how the plugin is registered
![PluginRegistration](https://raw.githubusercontent.com/rajyraman/AdvancedQueryOuterJoin/master/PluginRegistration.png)

This execution of the plugin is not restricted to just the Advanced Find. Basically, as you can see from the screenshot above, it runs for all RetrieveMultiple. If this is going to be performance issue, for your organisation, you can update the RetrieveMultiple step with an entity, that requires this functionality.
