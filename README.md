# YamlTransform
[![Build status](https://ci.appveyor.com/api/projects/status/8hlsio9gcq9u4416?svg=true)](https://ci.appveyor.com/project/berendhaan/ymltransform)
[![Build status](https://ci.appveyor.com/api/projects/status/8hlsio9gcq9u4416/branch/master?svg=true)](https://ci.appveyor.com/project/berendhaan/ymltransform/branch/master)

Transforms Sitecore Yml files during deployment. Like web transform for yml files. It throws an exception when a transform cannot be applied.

Example usage: `ymltransform.exe -p "App_Data/unicorn" -r -t "unicorn.ymltransform"`

Example transform file:
```json
[
    {
        "FieldId": "379de7bc-88f2-42ae-8d4a-50dd0b8796ea",
        "Languages": "",
        "Path": "/sitecore/content/Home/YourItem",
        "Type": "Shared",
        "Value": "https://the-new-value.com"
    }
]
```

Commandline switches:
```
-p, --path         Required. Path to folder containing .yml files
-t, --transform    Required. Transformation file
-r, --recursive    (Default: False) Loop recursively
```