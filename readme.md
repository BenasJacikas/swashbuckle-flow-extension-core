[![Build Status](https://travis-ci.org/BenasJacikas/swashbuckle-flow-extension-core.svg?branch=master)](https://travis-ci.org/BenasJacikas/swashbuckle-flow-extension-core)

Introduction
============

This package was created to extend swagger generation in order to support functionality required for MS Flow. [Documentation](https://flow.microsoft.com/en-us/documentation/customapi-how-to-swagger).

Inspired by [T-Rex](https://github.com/nihaue/TRex/tree/powerapps) 

Built upon [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore).

Usage
=====

## Nuget package
```
Install-Package Swashbuckle.AspNetCore.MicrosoftExtensions
```

## Metadata
Metadata attribute can be used for methods, parameters and properties
### Example
Code:
```
public class MetdataAttributeClass
{
    [Metadata("Summary", "Description", VisibilityType.Advanced)]
    public string Name { get; }

    public MetdataAttributeClass(string name)
    {
        Name = name;
    }
}
```

Generated swagger:
```
"MetdataAttributeClass": {
    "type": "object",
    "properties": {
        "name": {
            "type": "string",
            "readOnly": true,
            "x-ms-visibility": "advanced",
            "x-ms-summary": "Summary",
            "description": "Description"
        }
    }
}
```

## Dynamic value lookup
Dynamic value lookup can be used for properties and parameters
### Example
Code:
```
public class DynamicValueController : Controller
{
    [HttpGet]
    [Route("api/dynamic")]
    public void Get
    (
        [DynamicValueLookup("opId", "id", "name", parameters: "test=static&test2={dynamic}")]
        string dynamicValue
    ) { }
}
```
Swagger:
```
"/api/dynamic": {
    "get": {
        "tags": [ "DynamicValue" ],
        "operationId": "ApiDynamicGet",
        "parameters": [
            {
                "name": "dynamicValue", "in": "query",
                "required": false,
                "type": "string",
                "x-ms-dynamic-values": {
                    "operationId": "opId",
                    "value-path": "id",
                    "value-title": "name",
                    "parameters": {
                        "test": "static",
                        "test2": {
                            "parameter": "dynamic"
                        }
                    }
                }
            }
        ],
        "responses": {
            "200": {
                "description": "Success"
            }
        }
    }
}
```

## Dynamic value lookup capability
Dynamic value lookup capability can be used for parameters
### Example
Code:
```
public class DynamicValueCapabilityController : Controller
    {
        [HttpGet]
        [Route("api/capability")]
        public void Get 
        (
            [DynamicValueLookupCapability("capabilityName", "id", "name", parameters: "isFolder=true&test=static&test2={dynamic}")]
            string dynamicValue
        ){ }
    }
```
Swagger:
```
"/api/capability": {
    "get": {
        "tags": [
            "DynamicValueCapability"
        ],
        "operationId": "ApiCapabilityGet",
        "parameters": [
            {
                "name": "dynamicValue",
                "in": "query",
                "required": false,
                "type": "string",
                "x-ms-dynamic-values": {
                    "capability": "capabilityName",
                    "value-path": "id",
                    "value-title": "name",
                    "parameters": {
                        "isFolder": true,
                        "test": "static",
                        "test2": {
                            "parameter": "dynamic"
                        }
                    }
                }
            }
        ],
        "responses": {
            "200": {
                "description": "Success",
                "schema": {
                    "$ref": "#/definitions/DynamicValueLookupCapabilityClass"
                }
            }
        }
    }
}
```

## Dynamic schema lookup
Dynamic schema lookup can be used for properties, parameters and classes
### Example
Code: 
```
[DynamicSchemaLookup("DynamicSchemaOpId", "schema", "param1={test}&param2=test")]
public class DynamicSchemaLookupClass : Dictionary<string, object> { }
```
Swagger:
```
"DynamicSchemaLookupClass": {
    "type": "object",
    "properties": { },
    "additionalProperties": {
        "type": "object"
    }
    "x-ms-dynamic-schema": {
        "operationId": "DynamicSchemaOpId",
        "value-path": "schema",
        "parameters": {
            "param1": {
                "parameter": "test"
            },
            "param2": "test"
        }
    }
}
```

## File picker capability
#### Note: file picker design is not final, might change in the future from Microsoft's side
File picker capability can be used in GenerateMicrosoftExtensions method
### Examples
Code:
```
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();

    var filePicker = new FilePickerCapabilityModel
    (
        new FilePickerOperationModel("InitialOperation", null),
        new FilePickerOperationModel("BrowsingOperation", new Dictionary<string, string> {{"Id", "Id"}}),
        "Name",
        "IsFolder",
        "MediaType"
    );
    
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        c.GenerateMicrosoftExtensions(filePicker);
    });
}
```
Swagger:
```
"x-ms-capabilities": {
    "open": {
        "operation-id": "InitialOperation"
    },
    "browse": {
        "operation-id": "BrowsingOperation",
        "parameters": {
            "Id": {
                "value-property": "Id"
            }
        }
    },
    "value-title": "Name",
    "value-folder-property": "IsFolder",
    "value-media-property": "MediaType"
}
```

## Parameters
Current solution for parameters is that they are given as a query string, dynamic parameters are passed in braces {}
### Examples
Code:
```
parameters: "staticParam=true"
```
Swagger:
```
"parameters": {
    "staticParameter": true
}
```
Code:
```
parameters: "dynamicParam={previuoslyDefinedParam}"
```
Swagger:
```
"parameters": {
    "dynamicParam": {
        "parameter": "previouslyDefinedParam"
    }
}
```
Code: 
```
parameters: "staticParam=true&dynamicParam={previouslyDefinedParam}&moreDynamic={example}"
```
Swagger:
```
"parameters": {
    "staticParam": true,
    "dynamicParam": {
        "parameter": "previouslyDefinedParam"
    },
    "moreDynamic": {
        "parameter": "example"
    }
}
```
