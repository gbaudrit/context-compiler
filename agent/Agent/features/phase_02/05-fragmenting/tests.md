# Fragmenting — Required Tests (Ultra)

1. single mode yields exactly 1 fragment.
2. chunks mode yields ceil(n/maxRows) fragments with stable boundaries.
3. groupBy yields fragments ordered by group key ordinal.
4. locators include correct chunk/group suffix.
5. identical input produces identical fragment ids and order.
