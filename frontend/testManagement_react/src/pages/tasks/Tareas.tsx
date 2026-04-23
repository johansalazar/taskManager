
import React from 'react';
import { useParams, Link } from 'react-router-dom';
import ListaTareas from '../../components/tasks/ListaTareas';


const TasksPage: React.FC = () => {

    const { id } = useParams<{ id: string }>();
    const proyectoId = parseInt(id || "0", 10);

    return (
        <div className="min-h-screen bg-gray-50">
            <div className="container mx-auto p-6">
                <Link
                    to="/"
                    className="inline-flex items-center text-sm font-semibold text-blue-600 hover:text-blue-800 transition-colors mb-6 group"
                >
                    <span className="mr-2 group-hover:-translate-x-1 transition-transform">←</span>
                    Volver a Proyectos
                </Link>

                {proyectoId > 0 ? (
                    <ListaTareas proyectoId={proyectoId} />
                ) : (
                    <div className="bg-white p-10 rounded-3xl shadow-sm border border-red-100 text-center">
                        <h2 className="text-red-500 font-bold text-xl">ID de Proyecto no válido</h2>
                        <p className="text-gray-500 mt-2">No pudimos encontrar la referencia del proyecto en la URL.</p>
                    </div>
                )}
            </div>
        </div>
    );
};

export default TasksPage;