export type EstadoTarea = "Pendiente" | "EnProgreso" | "Completada";

export interface Tarea {
  id: number;
  titulo: string;
  descripcion: string;
  estado: EstadoTarea;
  fechaCreacion: string;
  fechaVencimiento: string;
  proyectoId: number;
}

export interface Proyecto {
  id: number;
  titulo: string;
  fechaCreacion: string;
  tareas: Tarea[];
}

export interface CrearTareaDTO {
  titulo: string;
  descripcion: string;
  estado: EstadoTarea;
  fechaCreacion: string;
  fechaVencimiento: string;
  proyectoId: number;
}