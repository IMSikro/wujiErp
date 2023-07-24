import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react-swc'

// https://vitejs.dev/config/
export default defineConfig(({ mode }) => {
  // process.env = { ...process.env, ...loadEnv(mode, process.cwd()) };
  const env = loadEnv(mode, process.cwd(), '');
  return {
    plugins: [react()],
    base: './',
    build: {
      outDir: 'build'
    },
    preview: {
      port: process.env.VITE_PORT || 7754
    },
    server: {
      host: process.env.VITE_HOST || 'localhost',
      port: process.env.VITE_PORT || 7753
    },
    define: {
      __APP_ENV__: JSON.stringify(env.APP_ENV),
    },
  };
})
