import { api } from './api.ts';
import type { CrearTareaDTO, EstadoTarea, Tarea } from "../types";

export const tareaService = {

    crearTarea: async (tarea: CrearTareaDTO): Promise<Tarea> => {
        const { data } = await api.post<Tarea>("/Tareas", tarea);
        return data;
    },

    cambiarEstadoTarea: async (id: number, estado: EstadoTarea): Promise<Tarea> => {
        // Usamos el objeto shorthand para { estado: estado }
        const { data } = await api.put<Tarea>(`/Tareas/${id}/estado`, { estado });
        return data;
    }
};