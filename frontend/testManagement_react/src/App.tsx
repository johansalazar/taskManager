import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { useState } from 'react';
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";

import ProjectsPage from "./pages/projects/Proyectos";
import TasksPage from "./pages/tasks/Tareas";

function App() {
  // Inicialización estable del cliente
  const [queryClient] = useState(() => new QueryClient({
    defaultOptions: {
      queries: {
        staleTime: 1000 * 60 * 5,
        retry: 1,
      },
    },
  }));

  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <div className="min-h-screen bg-[#f8fafc] text-slate-900 font-sans">
          <nav className="bg-white border-b border-slate-200 px-6 py-4 mb-8 shadow-sm">
            <div className="container mx-auto min-h-screen">
              <span className="text-xl font-bold bg-gradient-to-r from-blue-600 to-indigo-600 bg-clip-text text-transparent">
                TaskManager Pro
              </span>
            </div>
          </nav>
          <main className="container mx-auto px-4 pb-12">
            <Routes>
              <Route path="/" element={<ProjectsPage />} />
              <Route path="/tasks/:id" element={<TasksPage />} />
              <Route path="*" element={<Navigate to="/" replace />} />
            </Routes>
          </main>
        </div>
      </BrowserRouter>
      <ReactQueryDevtools initialIsOpen={false} />
    </QueryClientProvider>
  );
}

export default App;