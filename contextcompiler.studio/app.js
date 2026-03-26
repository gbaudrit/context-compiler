const SCHEMAS = {
  core: "https://context-compiler.local/schemas/ctxc.config.schema.json",
  excel: "https://context-compiler.local/schemas/plugin.readers.excel/ctxc.config.schema.json",
};

const coreOutput = document.querySelector("#core-output");
const excelOutput = document.querySelector("#excel-output");
const excelEmbedOutput = document.querySelector("#excel-embed-output");

const mapLists = {
  audiences: document.querySelector("#audiences-list"),
  glossary: document.querySelector("#glossary-list"),
};

const filesList = document.querySelector("#files-list");
const viewsList = document.querySelector("#views-list");
const whereList = document.querySelector("#where-list");

const mapTemplate = document.querySelector("#map-row-template");
const fileTemplate = document.querySelector("#file-rule-template");
const viewTemplate = document.querySelector("#view-rule-template");
const whereTemplate = document.querySelector("#where-rule-template");

const parseLines = (value) =>
  value
    .split(/\r?\n/)
    .map((line) => line.trim())
    .filter(Boolean);

const safeJsonParse = (value, fallback) => {
  const trimmed = value.trim();
  if (!trimmed) {
    return fallback;
  }

  try {
    return JSON.parse(trimmed);
  } catch {
    return fallback;
  }
};

const readMapList = (container) => {
  const entries = [...container.querySelectorAll(".inline-row")]
    .map((row) => {
      const key = row.querySelector(".map-key")?.value.trim();
      const value = row.querySelector(".map-value")?.value.trim();
      return key && value ? [key, value] : null;
    })
    .filter(Boolean);

  return Object.fromEntries(entries);
};

const buildCoreConfig = () => {
  const files = [...filesList.querySelectorAll(".stack-card")]
    .map((card) => {
      const match = card.querySelector(".file-match")?.value.trim();
      const includes = parseLines(card.querySelector(".file-includes")?.value ?? "");
      const options = safeJsonParse(card.querySelector(".file-options")?.value ?? "", {});

      const fileConfig = {
        $schema: SCHEMAS.core,
        options,
      };

      if (match) {
        fileConfig.match = match;
      }

      if (includes.length > 0) {
        fileConfig.includes = includes;
      }

      return match || includes.length > 0 ? fileConfig : null;
    })
    .filter(Boolean);

  const views = [...viewsList.querySelectorAll(".stack-card")]
    .map((card) => {
      const id = card.querySelector(".view-id")?.value.trim();
      const select = parseLines(card.querySelector(".view-select")?.value ?? "");
      if (!id) {
        return null;
      }

      const result = { id };
      if (select.length > 0) {
        result.select = select;
      }
      return result;
    })
    .filter(Boolean);

  return {
    $schema: SCHEMAS.core,
    context: {
      enabled: document.querySelector("#core-enabled").checked,
      name: document.querySelector("#core-name").value.trim(),
      summary: document.querySelector("#core-summary").value.trim(),
      domain: document.querySelector("#core-domain").value.trim(),
      audiences: readMapList(mapLists.audiences),
      objectives: parseLines(document.querySelector("#core-objectives").value),
      assumptions: parseLines(document.querySelector("#core-assumptions").value),
      constraints: {
        canUseExternalSources: document.querySelector("#core-external").checked,
        must: parseLines(document.querySelector("#core-must").value),
        mustNot: parseLines(document.querySelector("#core-must-not").value),
      },
      glossary: readMapList(mapLists.glossary),
    },
    personas: {
      active: parseLines(document.querySelector("#core-personas-active").value),
      mode: document.querySelector("#core-personas-mode").value,
      params: safeJsonParse(document.querySelector("#core-personas-params").value, {}),
    },
    files,
    views: {
      inline: document.querySelector("#views-inline").checked,
      views,
    },
  };
};

const parseWhereValue = (value) => {
  const trimmed = value.trim();
  if (!trimmed) {
    return "";
  }

  try {
    return JSON.parse(trimmed);
  } catch {
    return trimmed;
  }
};

const buildExcelConfig = () => {
  const where = [...whereList.querySelectorAll(".stack-card")]
    .map((card) => {
      const col = card.querySelector(".where-col")?.value.trim();
      const op = card.querySelector(".where-op")?.value.trim();
      const rawValue = card.querySelector(".where-value")?.value ?? "";

      if (!col || !op) {
        return null;
      }

      return {
        col,
        op,
        value: parseWhereValue(rawValue),
      };
    })
    .filter(Boolean);

  const excelConfig = {
    $schema: SCHEMAS.excel,
    id: document.querySelector("#excel-id").value.trim(),
    label: document.querySelector("#excel-label").value.trim(),
  };

  const sheet = document.querySelector("#excel-sheet").value.trim();
  const table = document.querySelector("#excel-table").value.trim();
  const skip = document.querySelector("#excel-skip").value;
  const headerRowIndex = document.querySelector("#excel-header-row-index").value;
  const select = parseLines(document.querySelector("#excel-select").value);
  const tags = parseLines(document.querySelector("#excel-tags").value);

  if (sheet) excelConfig.sheet = sheet;
  if (table) excelConfig.table = table;
  if (skip !== "") excelConfig.skip = Number(skip);
  if (headerRowIndex !== "") excelConfig.headerRowIndex = Number(headerRowIndex);
  if (select.length > 0) excelConfig.select = select;
  if (where.length > 0) excelConfig.where = where;
  if (tags.length > 0) excelConfig.tags = tags;

  return excelConfig;
};

const renderOutputs = () => {
  const coreConfig = buildCoreConfig();
  const excelConfig = buildExcelConfig();

  coreOutput.textContent = JSON.stringify(coreConfig, null, 2);
  excelOutput.textContent = JSON.stringify(excelConfig, null, 2);
  excelEmbedOutput.textContent = JSON.stringify({ excel: excelConfig }, null, 2);
};

const downloadJson = (filename, value) => {
  const blob = new Blob([JSON.stringify(value, null, 2)], { type: "application/json" });
  const url = URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = filename;
  link.click();
  URL.revokeObjectURL(url);
};

const copyText = async (text) => {
  await navigator.clipboard.writeText(text);
};

const wireContainer = (container) => {
  container.addEventListener("input", renderOutputs);
  container.addEventListener("change", renderOutputs);
  container.addEventListener("click", (event) => {
    const button = event.target.closest(".remove-row");
    if (!button) {
      return;
    }

    const row = button.closest(".inline-row, .stack-card");
    row?.remove();
    renderOutputs();
  });
};

const addMapRow = (kind, key = "", value = "") => {
  const fragment = mapTemplate.content.cloneNode(true);
  const row = fragment.querySelector(".inline-row");
  row.querySelector(".map-key").value = key;
  row.querySelector(".map-value").value = value;
  mapLists[kind].append(fragment);
};

const addFileRule = (data = {}) => {
  const fragment = fileTemplate.content.cloneNode(true);
  const card = fragment.querySelector(".stack-card");
  card.querySelector(".file-match").value = data.match ?? "";
  card.querySelector(".file-includes").value = (data.includes ?? []).join("\n");
  card.querySelector(".file-options").value = data.options ? JSON.stringify(data.options, null, 2) : "";
  filesList.append(fragment);
};

const addViewRule = (data = {}) => {
  const fragment = viewTemplate.content.cloneNode(true);
  const card = fragment.querySelector(".stack-card");
  card.querySelector(".view-id").value = data.id ?? "";
  card.querySelector(".view-select").value = (data.select ?? []).join("\n");
  viewsList.append(fragment);
};

const addWhereRule = (data = {}) => {
  const fragment = whereTemplate.content.cloneNode(true);
  const card = fragment.querySelector(".stack-card");
  card.querySelector(".where-col").value = data.col ?? "";
  card.querySelector(".where-op").value = data.op ?? "eq";
  if (Object.hasOwn(data, "value")) {
    card.querySelector(".where-value").value =
      typeof data.value === "string" ? data.value : JSON.stringify(data.value, null, 2);
  }
  whereList.append(fragment);
};

const seedCore = () => {
  mapLists.audiences.innerHTML = "";
  mapLists.glossary.innerHTML = "";
  filesList.innerHTML = "";
  viewsList.innerHTML = "";

  document.querySelector("#core-enabled").checked = true;
  document.querySelector("#core-name").value = "Context Compiler";
  document.querySelector("#core-summary").value = "Pre-LLM deterministic context compiler.";
  document.querySelector("#core-domain").value = "context-engineering";
  document.querySelector("#core-objectives").value = [
    "Compile heterogeneous inputs into governed reasoning context.",
    "Preserve traceability via Evidence IDs.",
  ].join("\n");
  document.querySelector("#core-assumptions").value = "The compiler never calls an LLM.";
  document.querySelector("#core-external").checked = false;
  document.querySelector("#core-must").value = "Preserve Evidence IDs verbatim.";
  document.querySelector("#core-must-not").value = "Invent facts or identifiers.";
  document.querySelector("#core-personas-active").value = [
    "analysts.business",
    "developers.dotnetcore",
  ].join("\n");
  document.querySelector("#core-personas-mode").value = "append";
  document.querySelector("#core-personas-params").value = JSON.stringify({
    "analysts.business": {
      language: "fr",
      style: "direct",
    },
  }, null, 2);
  document.querySelector("#views-inline").checked = false;

  addMapRow("audiences", "dev", "Engineering audience");
  addMapRow("audiences", "security", "Security audience");
  addMapRow("glossary", "Reasoning IR", "Canonical internal representation.");
  addMapRow("glossary", "Evidence", "Traceable fragment reference.");

  addFileRule({
    match: "docs/**/*.md",
    options: {
      excel: {
        id: "requirements_extract",
        label: "Requirements Extract",
      },
    },
  });

  addViewRule({ id: "default", select: ["*"] });
};

const seedExcel = () => {
  whereList.innerHTML = "";

  document.querySelector("#excel-id").value = "requirements_extract";
  document.querySelector("#excel-label").value = "Requirements Extract";
  document.querySelector("#excel-sheet").value = "Requirements";
  document.querySelector("#excel-table").value = "";
  document.querySelector("#excel-skip").value = "0";
  document.querySelector("#excel-header-row-index").value = "0";
  document.querySelector("#excel-select").value = ["Id", "Title", "Status"].join("\n");
  document.querySelector("#excel-tags").value = ["excel", "requirements"].join("\n");

  addWhereRule({
    col: "Status",
    op: "eq",
    value: "Approved",
  });
};

document.querySelectorAll("input, textarea, select").forEach((element) => {
  element.addEventListener("input", renderOutputs);
  element.addEventListener("change", renderOutputs);
});

wireContainer(mapLists.audiences);
wireContainer(mapLists.glossary);
wireContainer(filesList);
wireContainer(viewsList);
wireContainer(whereList);

document.querySelectorAll("[data-add-map]").forEach((button) => {
  button.addEventListener("click", () => {
    addMapRow(button.dataset.addMap, "", "");
    renderOutputs();
  });
});

document.querySelector("#add-file-rule").addEventListener("click", () => {
  addFileRule();
  renderOutputs();
});

document.querySelector("#add-view-rule").addEventListener("click", () => {
  addViewRule();
  renderOutputs();
});

document.querySelector("#add-where-rule").addEventListener("click", () => {
  addWhereRule();
  renderOutputs();
});

document.querySelector("#reset-core").addEventListener("click", () => {
  seedCore();
  renderOutputs();
});

document.querySelector("#reset-excel").addEventListener("click", () => {
  seedExcel();
  renderOutputs();
});

document.querySelector("#copy-core").addEventListener("click", async () => {
  await copyText(JSON.stringify(buildCoreConfig(), null, 2));
});

document.querySelector("#copy-excel").addEventListener("click", async () => {
  await copyText(JSON.stringify(buildExcelConfig(), null, 2));
});

document.querySelector("#download-core").addEventListener("click", () => {
  downloadJson("ctxc.config.json", buildCoreConfig());
});

document.querySelector("#download-excel").addEventListener("click", () => {
  downloadJson("ctxc.excel.config.json", buildExcelConfig());
});

seedCore();
seedExcel();
renderOutputs();
