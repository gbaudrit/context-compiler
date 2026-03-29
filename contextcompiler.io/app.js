const navToggle = document.querySelector(".nav-toggle");
const siteNav = document.querySelector(".site-nav");
const yearTarget = document.querySelector("#year");
const revealNodes = document.querySelectorAll(".reveal");
const artifactTabs = document.querySelectorAll(".artifact-tab");
const artifactPanels = document.querySelectorAll(".artifact-panel");
const artifactTabsContainer = document.querySelector(".artifact-tabs");
const artifactPreview = document.querySelector(".artifact-preview");
const packagesGrid = document.querySelector("#packages-grid");
const packagesSearch = document.querySelector("#packages-search");
const packagesSummaryText = document.querySelector("#packages-summary-text");
const packagesFamilyFilters = document.querySelector("#packages-family-filters");
const packageKindButtons = document.querySelectorAll(".packages-kind-button");

let packagesCatalog = null;
let activePackageKind = "packs";
let activePackageFamily = "all";

if (navToggle && siteNav) {
  navToggle.addEventListener("click", () => {
    const expanded = navToggle.getAttribute("aria-expanded") === "true";
    navToggle.setAttribute("aria-expanded", String(!expanded));
    siteNav.classList.toggle("is-open");
  });
}

if (yearTarget) {
  yearTarget.textContent = String(new Date().getFullYear());
}

const setActiveArtifact = (artifactName) => {
  for (const tab of artifactTabs) {
    tab.classList.toggle("is-active", tab.dataset.artifact === artifactName);
  }

  for (const panel of artifactPanels) {
    panel.classList.toggle("is-active", panel.dataset.panel === artifactName);
  }

  syncArtifactPreviewPosition();
};

const syncArtifactPreviewPosition = () => {
  if (!artifactTabsContainer || !artifactPreview || window.innerWidth <= 1080) {
    if (artifactPreview) {
      artifactPreview.style.transform = "";
    }
    return;
  }

  const activeTab = document.querySelector(".artifact-tab.is-active");
  if (!activeTab) {
    return;
  }

  const tabsRect = artifactTabsContainer.getBoundingClientRect();
  const activeRect = activeTab.getBoundingClientRect();
  const previewHeight = artifactPreview.offsetHeight;
  const tabsHeight = artifactTabsContainer.offsetHeight;

  const desiredOffset = activeRect.top - tabsRect.top;
  const maxOffset = Math.max(0, tabsHeight - previewHeight);
  const offset = Math.max(0, Math.min(desiredOffset, maxOffset));

  artifactPreview.style.transform = `translateY(${offset}px)`;
};

for (const tab of artifactTabs) {
  tab.addEventListener("mouseenter", () => setActiveArtifact(tab.dataset.artifact));
  tab.addEventListener("focus", () => setActiveArtifact(tab.dataset.artifact));
  tab.addEventListener("click", () => setActiveArtifact(tab.dataset.artifact));
}

const formatPackageCount = (count, singular, plural) =>
  `${count} ${count > 1 ? plural : singular}`;

const escapeHtml = (value) =>
  String(value)
    .replaceAll("&", "&amp;")
    .replaceAll("<", "&lt;")
    .replaceAll(">", "&gt;")
    .replaceAll('"', "&quot;")
    .replaceAll("'", "&#39;");

const renderFamilyFilters = (families) => {
  if (!packagesFamilyFilters) {
    return;
  }

  const buttons = [
    `<button type="button" class="packages-family-button${activePackageFamily === "all" ? " is-active" : ""}" data-family="all">Toutes</button>`,
    ...families.map((family) =>
      `<button type="button" class="packages-family-button${activePackageFamily === family ? " is-active" : ""}" data-family="${escapeHtml(family)}">${escapeHtml(family)}</button>`
    ),
  ];

  packagesFamilyFilters.innerHTML = buttons.join("");
};

const renderPackages = () => {
  if (!packagesCatalog || !packagesGrid || !packagesSummaryText) {
    return;
  }

  const allItems = packagesCatalog[activePackageKind] ?? [];
  const query = packagesSearch?.value.trim().toLowerCase() ?? "";

  const families = [...new Set(allItems.map((item) => item.family).filter(Boolean))].sort((a, b) =>
    a.localeCompare(b)
  );

  renderFamilyFilters(families);

  const filteredItems = allItems.filter((item) => {
    const matchesFamily = activePackageFamily === "all" || item.family === activePackageFamily;
    const haystack = [
      item.packageId,
      item.shortName,
      item.description,
      item.family,
      ...(item.includes ?? []),
    ]
      .filter(Boolean)
      .join(" ")
      .toLowerCase();

    return matchesFamily && (!query || haystack.includes(query));
  });

  const kindLabel = activePackageKind === "modules" ? "modules" : "packs";
  packagesSummaryText.textContent = `${formatPackageCount(filteredItems.length, kindLabel === "modules" ? "module" : "pack", kindLabel)} affichés sur ${allItems.length}.`;

  if (filteredItems.length === 0) {
    packagesGrid.innerHTML = `
      <article class="package-empty">
        <h3>Aucun package trouvé</h3>
        <p>Essaie une autre recherche ou une autre famille.</p>
      </article>
    `;
    return;
  }

  packagesGrid.innerHTML = filteredItems
    .map((item) => {
      const includes = item.includes?.length
        ? `
          <div class="package-includes">
            <p class="package-meta-label">Contient</p>
            <ul>
              ${item.includes.map((entry) => `<li><code>${escapeHtml(entry)}</code></li>`).join("")}
            </ul>
          </div>
        `
        : "";

      return `
        <article class="package-card">
          <div class="package-card-top">
            <p class="package-family">${escapeHtml(item.family || "Other")}</p>
            <div class="package-kind-stack">
              <span class="package-kind">${activePackageKind === "modules" ? "Module unitaire" : "Pack"}</span>
              ${item.compositionKind === "pack-of-packs" ? '<span class="package-subkind">Pack de packs</span>' : ""}
              ${item.compositionKind === "pack-of-modules" ? '<span class="package-subkind">Pack de modules</span>' : ""}
            </div>
          </div>
          <h3><code>${escapeHtml(item.packageId)}</code></h3>
          <p>${escapeHtml(item.description || "Description à compléter dans le package.")}</p>
          ${activePackageKind === "packs" ? includes : ""}
          <div class="package-links">
            <a class="package-link package-link-primary" href="${escapeHtml(item.nugetUrl)}" target="_blank" rel="noreferrer">
              <span>NuGet.org</span>
            </a>
            <a class="package-link package-link-secondary" href="${escapeHtml(item.githubUrl)}" target="_blank" rel="noreferrer">
              <svg viewBox="0 0 24 24" aria-hidden="true" focusable="false">
                <path d="M12 1.5C6.201 1.5 1.5 6.347 1.5 12.326c0 4.783 3.008 8.839 7.18 10.271.525.101.717-.233.717-.519 0-.257-.01-1.105-.015-2.003-2.921.651-3.537-1.451-3.537-1.451-.477-1.25-1.166-1.582-1.166-1.582-.954-.671.072-.658.072-.658 1.055.076 1.61 1.119 1.61 1.119.938 1.647 2.46 1.171 3.06.896.095-.699.367-1.171.667-1.44-2.332-.272-4.784-1.204-4.784-5.357 0-1.183.41-2.151 1.082-2.91-.108-.273-.469-1.37.103-2.856 0 0 .882-.29 2.89 1.111A9.81 9.81 0 0 1 12 7.103c.87.004 1.747.12 2.565.353 2.007-1.4 2.887-1.111 2.887-1.111.574 1.486.213 2.583.105 2.856.674.759 1.08 1.727 1.08 2.91 0 4.163-2.456 5.081-4.794 5.348.377.333.713.988.713 1.992 0 1.439-.013 2.599-.013 2.953 0 .288.189.625.722.518 4.169-1.434 7.174-5.489 7.174-10.27C22.5 6.347 17.799 1.5 12 1.5Z" fill="currentColor"/>
              </svg>
              <span>Source</span>
            </a>
          </div>
        </article>
      `;
    })
    .join("");
};

const loadPackagesCatalog = async () => {
  if (!packagesGrid) {
    return;
  }

  try {
    const response = await fetch("data/packages.catalog.json");
    if (!response.ok) {
      throw new Error(`HTTP ${response.status}`);
    }

    packagesCatalog = await response.json();
    renderPackages();
  } catch (error) {
    packagesSummaryText.textContent = "Impossible de charger le catalogue.";
    packagesGrid.innerHTML = `
      <article class="package-empty">
        <h3>Catalogue indisponible</h3>
        <p>Le fichier <code>data/packages.catalog.json</code> n'a pas pu être chargé.</p>
      </article>
    `;
  }
};

for (const button of packageKindButtons) {
  button.addEventListener("click", () => {
    activePackageKind = button.dataset.kind;
    activePackageFamily = "all";

    for (const sibling of packageKindButtons) {
      const isActive = sibling === button;
      sibling.classList.toggle("is-active", isActive);
      sibling.setAttribute("aria-pressed", String(isActive));
    }

    renderPackages();
  });
}

packagesFamilyFilters?.addEventListener("click", (event) => {
  const button = event.target.closest(".packages-family-button");
  if (!button) {
    return;
  }

  activePackageFamily = button.dataset.family;
  renderPackages();
});

packagesSearch?.addEventListener("input", renderPackages);

window.addEventListener("resize", syncArtifactPreviewPosition);
window.addEventListener("load", syncArtifactPreviewPosition);
window.addEventListener("load", loadPackagesCatalog);

const observer = new IntersectionObserver(
  (entries) => {
    for (const entry of entries) {
      if (entry.isIntersecting) {
        entry.target.classList.add("is-visible");
        observer.unobserve(entry.target);
      }
    }
  },
  { threshold: 0.12 }
);

for (const node of revealNodes) {
  observer.observe(node);
}
