# d20231214-CreateSlimBuilder
Explores the new .NET 8 WebApplication.CreateSlimBuilder() method.

This is useful for native ahead-of-time (AOT) compilation, where you might not want *ALL* of the APIs added by the full web application (since they will expand the size of the AOT compiled binary). The slim builder allows you to start with a far more restricted (but still basically useful) API set, adding in only what you need over and above the basically useful.

Link: https://www.youtube.com/watch?v=CEYaPoYZ_38

