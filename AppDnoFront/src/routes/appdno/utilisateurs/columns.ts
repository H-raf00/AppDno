import type { ColumnDef } from "@tanstack/table-core";

export type User = {
    lastName: string;
    role: string;
    group: string;
    projectNumber: number;
};

export const columns: ColumnDef<User>[] = [
    {
        accessorKey: "lastName",
        header: "Nom",
    },
    {
        accessorKey: "role",
        header: "Rôle",
    },
    {
        accessorKey: "group",
        header: "Groupe",
    },
    {
        accessorKey: "projectNumber",
        header: "Nombre de projets",
    },
];