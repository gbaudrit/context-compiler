import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  // Use relative paths for file:// protocol compatibility
  base: './',
  build: {
    // Inline all assets to create a single HTML file
    assetsInlineLimit: 100000000, // 100MB - inline everything
    cssCodeSplit: false,
    rollupOptions: {
      output: {
        // Generate single files without hashes
        entryFileNames: 'assets/[name].js',
        chunkFileNames: 'assets/[name].js',
        assetFileNames: 'assets/[name].[ext]',
        // Inline all chunks
        inlineDynamicImports: true,
        // Use IIFE format instead of ES modules to avoid CORS issues with file://
        format: 'iife',
      },
    },
  },
  // Optimize dependencies
  optimizeDeps: {
    include: ['react', 'react-dom', 'reactflow', 'elkjs', 'zustand'],
  },
})
