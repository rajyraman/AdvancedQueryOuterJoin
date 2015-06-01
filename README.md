CRM2015 doesn't allow outer join queries through the UI. This plugin enabled you to do that. The plugin runs on pre-RetrieveMultiple and alter the query that gets sent to the pipeline, with the correct outer join conditions.

Basically the plugin enables you to do advanced find queries like this
![AdvancedFind](https://raw.githubusercontent.com/rajyraman/AdvancedQueryOuterJoin/master/OuterJoin.png)

Without the plugin running in the background, you would normally get no records, for a query like the one above. The query above retrieves account that have child contacts, but don't have any opportunities.

This is how the plugin is registered
![PluginRegistration](https://raw.githubusercontent.com/rajyraman/AdvancedQueryOuterJoin/master/PluginRegistration.png)

The execution of this plugin is not restricted to just the Advanced Find. Basically, as you can see from the screenshot above, it runs for all RetrieveMultiple requests. If this is going to be performance issue for your CRM instance, you can update the RetrieveMultiple step with an entity, that requires this functionality. The code has to be modified slightly as well.
