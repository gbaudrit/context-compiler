# Default transcoders pack

`ContextCompiler.Packs.Datas.Transcoders.Default` bundles the default transcoder modules for ContextCompiler.

Included modules:

- `ContextCompiler.Modules.Datas.Transcoders.Linear` - Handles linear data shapes (text, files)
- `ContextCompiler.Modules.Datas.Transcoders.Tabular` - Handles tabular data shapes (tables, structured data)

Use this pack when you need to transcode linear and tabular data into fragments for further processing in the ContextCompiler pipeline.

## Features

- **Linear Transcoder**: Processes text content and file references with custom locators
- **Tabular Transcoder**: Serializes structured data to JSON format with indentation

## Priority

Both transcoders have a priority of 10, making them preferred over the built-in default transcoder (priority 0) when available.
