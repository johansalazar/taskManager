import React from "react";
import { useQuery } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom"; // Importante para la navegación
import { proyectoService } from "../../services/proyectoService";

// Definimos una interfaz local si no la tienes importada para evitar errores de 'any'
interface Proyecto {
  id: number;
  titulo: string;
}

const ListaProyectos: React.FC = () => {
  const navigate = useNavigate();

  const { data: proyectos, isLoading, isError } = useQuery<Proyecto[]>({
    queryKey: ['proyectos'],
    queryFn: proyectoService.getProyectos,
    // Añadimos una protección extra para React 19
    retry: 1,
  });

  // Renderizado condicional robusto
  if (isLoading) {
    return (
      <div className="flex items-center justify-center min-h-[400px]">
        <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500"></div>
        <span className="ml-3 text-gray-600 font-medium">Cargando proyectos...</span>
      </div>
    );
  }

  if (isError) {
    return (
      <div className="p-6 m-4 bg-red-50 border border-red-200 rounded-xl text-red-700">
        <p className="font-bold">⚠ Error de Conexión</p>
        <p className="text-sm">No pudimos conectar con la API de .NET. Revisa el CORS.</p>
      </div>
    );
  }

  return (
    <div className="max-w-6xl mx-auto">
      <header className="flex flex-col md:flex-row md:items-end justify-between gap-4 mb-10">
        <div>
          <h1 className="text-4xl font-extrabold tracking-tight text-slate-900 mb-2">
            Mis Proyectos
          </h1>
        </div>
      </header>
      <hr />
      <div style={{ textAlign: 'left' }} className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8 items-start">
        {proyectos?.map((proyecto) => (
          <><article
            key={proyecto.id}
            className="group bg-white border border-slate-200 rounded-2xl p-6 shadow-sm hover:shadow-xl hover:border-blue-300 transition-all duration-300"
          >
            <div className="flex justify-between items-start mb-4">
              <div className="p-3 bg-blue-50 rounded-lg group-hover:bg-blue-100 transition-colors">
                {/* Icono representativo */}
              </div>
              <span className="bg-emerald-50 text-emerald-700 text-[10px] font-bold px-2.5 py-1 rounded-full uppercase tracking-wider border border-emerald-100">
                Activo
              </span>
            </div>

            <h2 className="text-xl font-bold text-slate-800 mb-2 group-hover:text-blue-600 transition-colors">
              {proyecto.titulo}
            </h2>
            <div className="flex items-center justify-between pt-5 border-t border-slate-50">
              <span className="text-xs font-medium text-slate-400">ID: #{proyecto.id}</span>
              <br />
              <button
                onClick={() => navigate(`/tasks/${proyecto.id}`)}
                className="text-blue-600 hover:text-blue-800 font-bold text-sm flex items-center gap-1 group/btn"
              >
                Ver Tareas
                <span className="group-hover:translate-x-1 transition-transform">→</span>
              </button>
            </div>
          </article><hr /></>

        ))}

      </div>
    </div>
  );
};

export default ListaProyectos;