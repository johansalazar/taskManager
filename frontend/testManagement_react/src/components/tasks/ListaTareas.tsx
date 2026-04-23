import React from 'react';
import { useQuery } from '@tanstack/react-query';
import { proyectoService } from '../../services/proyectoService';
import type { EstadoTarea } from '../../types';

interface Props {
  proyectoId: number;
}

const ListaTareas: React.FC<Props> = ({ proyectoId }) => {


  const { data: proyecto, isLoading, isError } = useQuery({
    queryKey: ['proyecto', proyectoId],
    queryFn: () => proyectoService.getProyectoById(proyectoId.toString()),
    enabled: !!proyectoId,
  });

  // 2. Mutación optimizada

  if (isLoading) return <div className="text-center p-10 animate-pulse text-gray-500">Cargando tareas...</div>;

  if (isError) return (
    <div className="bg-red-50 text-red-600 p-4 rounded-lg border border-red-100">
      Error al cargar el proyecto #{proyectoId}
    </div>
  );

  const tareas = proyecto?.tareas || [];

  return (
    <div className="max-w-3xl mx-auto bg-white rounded-3xl shadow-xl shadow-slate-200/60 border border-slate-100 overflow-hidden">
      <div className="bg-slate-900 p-8 text-white">
        <h3 className="text-2xl font-bold">Tareas del Proyecto</h3>
        <p className="text-slate-400 text-sm mt-1">Organiza y actualiza el progreso</p>
      </div>
      <hr />
      <div className="p-6">
        <div className="space-y-4">
          {tareas.map((tarea) => (
            <><div
              key={tarea.id}
              className="flex items-center justify-between p-5 bg-slate-50 rounded-2xl border border-transparent hover:border-blue-200 hover:bg-white hover:shadow-md transition-all group"
              style={{ textAlign: 'justify' }}>
              <div className="flex items-center gap-4">
                <div className={`w-3 h-3 rounded-full ${getEstadoStyles(tarea.estado)}`} />
                <div>
                  <h4 className="font-bold text-slate-800 group-hover:text-blue-700 transition-colors">
                    {tarea.descripcion}
                  </h4>
                  <span className="text-[10px] font-black text-slate-400 uppercase tracking-widest">
                    Status: {tarea.estado}
                  </span>
                </div>
              </div>


            </div><hr /></>
          ))}
        </div>
      </div>
    </div>
  );
};

const getEstadoStyles = (estado: EstadoTarea) => {
  switch (estado) {
    case 'Completada': return 'bg-emerald-500 shadow-[0_0_8px_rgba(16,185,129,0.5)]';
    case 'EnProgreso': return 'bg-blue-500 shadow-[0_0_8px_rgba(59,130,246,0.5)]';
    default: return 'bg-amber-500 shadow-[0_0_8px_rgba(245,158,11,0.5)]';
  }
};

export default ListaTareas;