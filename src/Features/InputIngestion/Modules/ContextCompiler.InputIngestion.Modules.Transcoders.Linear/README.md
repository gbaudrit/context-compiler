# ContextCompiler.InputIngestion.Modules.Transcoders.Linear

## Description

Transcoder module specialized in handling linear data shapes. This module processes text content and file references, converting them into fragments suitable for further processing in the ContextCompiler pipeline.

## Features

- Processes `DataShape.Linear` envelopes
- Handles text strings and file information objects
- Adds appropriate tags to transcoded fragments
- Supports custom locators for different content types

## Usage

This module is automatically loaded by the ContextCompiler module system and processes linear data shapes with a priority of 10.

## Output

The module produces `TranscodedFragment` objects with:
- Locator: `file:full` for file content, or custom locator for text content
- Content: File path or text content
- Tags: Includes `shape:linear` tag plus any tags from the source data part
