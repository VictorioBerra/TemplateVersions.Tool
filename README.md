# TemplateVersions.Tool

[![Build status](https://ci.appveyor.com/api/projects/status/5qsnogdmqiue4v45/branch/master?svg=true)](https://ci.appveyor.com/project/VictorioBerra/templateversions-tool/branch/master)

Lists all the versions of dotnet core SDKs in your user template directory and the global tools for each version.

## Get started

Install:

```PowerShell
dotnet tool install -g TemplateVersions.Tool
```

list installed templates in the latest SDK

```PowerShell
templateversions
```

list installed SDKs in .templateengine folder:

```PowerShell
templateversions --list
```

list installed templates in the specific SDK

```PowerShell
templateversions --sdkversion "v2.2.401"
```

list installed templates in all SDKs

```PowerShell
templateversions --all
```

list installed templates in all SDKs but dont list the SDK version headers (makes it easier to see the same templates across versions)

```PowerShell
templateversions --noversionall
```

## LICENSE

MIT
