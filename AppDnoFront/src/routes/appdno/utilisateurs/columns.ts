import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table/index.js";
import DataTableButton from "./data-table-button.svelte";

export type User = {
    id : number;
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
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                userId: row.original.id,
            }),
    },
];