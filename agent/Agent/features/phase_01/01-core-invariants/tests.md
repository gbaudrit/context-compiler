# Core Invariants — Required Tests (Ultra)

These tests are *non-negotiable*. They protect the project's identity as a deterministic pre-LLM compiler.

## Unit tests (required)
1. **NoLLMCallContract**
   - Ensure the compilation engine has no dependency on any LLM client abstractions.
   - Ensure plugin interfaces do not include LLM interactions.
   - (If future agent layer exists, it must be outside the compiler core.)

2. **DeterministicOrderingContract**
   - Feed a fixed small dataset into a pipeline stage twice.
   - Assert output byte-for-byte identical (artifact content).

3. **TraceabilityContract**
   - Every fragment must have:
     - SourceRef (path + locator)
     - EvidenceKey
     - EvidenceRevision

4. **GuardEnforcementContract**
   - If any guard returns Critical+Block → compilation result is blocked (exit code 2).

## Integration tests (required)
5. **GoldenFolderDeterminism**
   - Compile a fixture folder twice.
   - Compare output folder tree (paths + file contents) exactly.

6. **SafeDeleteOutputFolder**
   - Ensure output folder contains only generated artifacts.
   - Ensure input folder remains unchanged.

## Anti-regression tests
7. **InvariantViolationStops**
   - Force an invariant failure in a mocked stage.
   - Verify the engine stops further stages and returns exit code 1.
