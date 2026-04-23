
import { api } from './api.ts';
import type { Proyecto } from "../types";

export const proyectoService = {

    getProyectos: async (): Promise<Proyecto[]> => {
        const { data } = await api.get<Proyecto[]>("/Proyectos");
        return data;
    },

    getProyectoById: async (id: string): Promise<Proyecto> => {
        const { data } = await api.get<Proyecto>(`/Proyectos/${id}`);
        return data;
    },

};