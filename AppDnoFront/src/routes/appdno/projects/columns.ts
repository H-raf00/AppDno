import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table/index.js";
import DataTableButton from "./data-table-button.svelte";

export type Project = {
    id: number;
    code: string;
    name: string;
    responsableId: number;
    responsableName: string;
    clientId: number;
    clientName: string;
    usersNumber: number;
    ingredientsNumber: number;
};

export const columns: ColumnDef<Project>[] = [
    {
        accessorKey: "code",
        header: "Code",
    },
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        accessorKey: "responsableName",
        header: "Responsable",
    },
    {
        accessorKey: "clientName",
        header: "Client",
    },
    {
        accessorKey: "usersNumber",
        header: "Utilisateurs",
    },
    {
        accessorKey: "ingredientsNumber",
        header: "Ingrédients",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                projectId: row.original.id,
            }),
    },
];
