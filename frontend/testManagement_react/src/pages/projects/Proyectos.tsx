import React from 'react';
import ListaProyectos from '../../components/projects/ListaProyectos';


const ProjectsPage: React.FC = () => {
    return (
        <div className="min-h-screen bg-gray-50">
            <main className="py-8">
                <ListaProyectos />
            </main>
        </div>
    );
};

export default ProjectsPage;