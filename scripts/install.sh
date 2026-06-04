#!/usr/bin/env bash
set -euo pipefail

VERSION="${VERSION:-latest}"
INSTALL_DIR="${INSTALL_DIR:-$HOME/.ctxc/bin}"
REPO="${REPO:-gbaudrit/context-compiler}"

OS="$(uname -s | tr '[:upper:]' '[:lower:]')"
ARCH="$(uname -m)"

case "$OS" in
  linux) OS_ID="linux" ;;
  darwin) OS_ID="osx" ;;
  *) echo "Unsupported OS: $OS" >&2; exit 1 ;;
esac

case "$ARCH" in
  x86_64|amd64) ARCH_ID="x64" ;;
  arm64|aarch64)
	if [ "$OS_ID" = "osx" ]; then ARCH_ID="arm64"; else ARCH_ID="x64"; fi
	;;
  *) echo "Unsupported architecture: $ARCH" >&2; exit 1 ;;
esac

ASSET="ctxc-${OS_ID}-${ARCH_ID}.tar.gz"

if [ "$VERSION" = "latest" ]; then
  URL="https://github.com/${REPO}/releases/latest/download/${ASSET}"
else
  URL="https://github.com/${REPO}/releases/download/${VERSION}/${ASSET}"
fi

mkdir -p "$INSTALL_DIR"
TMP="$(mktemp -d)"
trap 'rm -rf "$TMP"' EXIT

curl -fsSL "$URL" -o "$TMP/$ASSET"
tar -xzf "$TMP/$ASSET" -C "$INSTALL_DIR"
chmod +x "$INSTALL_DIR/ctxc" || true

echo "ContextCompiler installed in $INSTALL_DIR"
if ! command -v ctxc >/dev/null 2>&1; then
  echo "Add this to your shell profile:"
  echo "export PATH=\"$INSTALL_DIR:\$PATH\""
fi

"$INSTALL_DIR/ctxc" --version || true
