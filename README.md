
[![Build status](https://ci.appveyor.com/api/projects/status/5qsnogdmqiue4v45/branch/master?svg=true)](https://ci.appveyor.com/project/VictorioBerra/templateversions-tool/branch/master)

# TemplateVersions.Tool

Lists all the versions of dotnet core SDKs in your user template directory and the global tools for each version.


### Get started

Install:
```
$ dotnet tool install -g TemplateVersions.Tool
```

list installed templates in the latest SDK
```
$ templateversions
```

list installed SDKs in .templateengine folder:
```
$ templateversions --list
```

list installed templates in the specific SDK
```
$ templateversions --sdkversion "v2.2.401"
```