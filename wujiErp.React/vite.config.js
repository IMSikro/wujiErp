import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default ({ mode }) => {
  process.env = { ...process.env, ...loadEnv(mode, process.cwd()) };

  return defineConfig({
    plugins: [react()],
    base: './',
    build: {
      outDir: 'build'
    },
    preview: {
      port: process.env.VITE_PORT || 7754
    },
    server: {
      host: '0.0.0.0',
      port: process.env.VITE_PORT || 7753
    }
  });
} 
