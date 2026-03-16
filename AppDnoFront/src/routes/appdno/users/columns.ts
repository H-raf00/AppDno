import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { DataTableButton } from "$lib/components/ui/data-table-button";

export type User = {
    id : number;
    lastName: string;
    role: string;
    group: string;
    projectsNumber: number;
};

export const columns: ColumnDef<User>[] = [
    {
        accessorKey: "lastName",
        header: "Nom",
    },
    {
        accessorKey: "role",
        header: "Rôle",
        cell: ({ getValue }) => {
            const role = getValue();
            return role === 0 ? "admin" : "user";
        },
    },
    {
        accessorKey: "group",
        header: "Groupe",
    },
    {
        accessorKey: "projectsNumber",
        header: "Nombre de projets",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                route: `/appdno/users/${row.original.id}`,
            }),
    },
];