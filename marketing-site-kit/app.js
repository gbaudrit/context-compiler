const navToggle = document.querySelector(".nav-toggle");
const siteNav = document.querySelector(".site-nav");
const yearTarget = document.querySelector("#year");
const revealNodes = document.querySelectorAll(".reveal");
const artifactTabs = document.querySelectorAll(".artifact-tab");
const artifactPanels = document.querySelectorAll(".artifact-panel");
const artifactTabsContainer = document.querySelector(".artifact-tabs");
const artifactPreview = document.querySelector(".artifact-preview");

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

window.addEventListener("resize", syncArtifactPreviewPosition);
window.addEventListener("load", syncArtifactPreviewPosition);

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
