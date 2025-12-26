# MCP Tools — JSON Schemas (Ultra)

These schema fragments are intended for tool definitions.

## compile_context
Input schema:
```json
{
  "type":"object",
  "properties":{
    "inputPath":{"type":"string"},
    "outputPath":{"type":"string"},
    "configPath":{"type":"string"}
  },
  "required":["inputPath","outputPath"]
}
```

Output schema:
```json
{
  "type":"object",
  "properties":{
    "ok":{"type":"boolean"},
    "exitCode":{"type":"integer"},
    "artifacts":{"type":"array","items":{"type":"string"}}
  },
  "required":["ok","exitCode","artifacts"]
}
```

## list_artifacts
Input:
```json
{"type":"object","properties":{"outputPath":{"type":"string"}},"required":["outputPath"]}
```

Output:
```json
{"type":"object","properties":{"artifacts":{"type":"array","items":{"type":"string"}}},"required":["artifacts"]}
```

## read_artifact
Input:
```json
{
  "type":"object",
  "properties":{
    "outputPath":{"type":"string"},
    "artifactPath":{"type":"string"}
  },
  "required":["outputPath","artifactPath"]
}
```

Output:
```json
{
  "type":"object",
  "properties":{
    "content":{"type":"string"},
    "mime":{"type":"string"}
  },
  "required":["content","mime"]
}
```
