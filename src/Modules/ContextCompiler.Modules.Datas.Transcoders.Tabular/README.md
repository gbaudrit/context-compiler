# ContextCompiler.Modules.Datas.Transcoders.Tabular

## Description

Transcoder module specialized in handling tabular data shapes. This module processes structured data like tables and converts them into JSON format for further processing in the ContextCompiler pipeline.

## Features

- Processes `DataShape.Tabular` envelopes
- Serializes tabular data to indented JSON format
- Adds appropriate tags to transcoded fragments
- Preserves structured data relationships

## Usage

This module is automatically loaded by the ContextCompiler module system and processes tabular data shapes with a priority of 10.

## Output

The module produces `TranscodedFragment` objects with:
- Locator: `table:json`
- Content: JSON-serialized representation of the tabular data (with indentation)
- Tags: Includes `shape:tabular` tag plus any tags from the source data part

## JSON Format

The module uses `System.Text.Json` with `WriteIndented = true` to produce human-readable JSON output.
