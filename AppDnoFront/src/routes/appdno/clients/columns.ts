import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table/index.js";
import DataTableButton from "./data-table-button.svelte";

export type Client = {
    id : number;
    Name: string;
    projectNumber: number;
};

export const columns: ColumnDef<Client>[] = [
    {
        accessorKey: "Name",
        header: "Nom",
    },
    {
        accessorKey: "projectNumber",
        header: "Nombre de projets",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                clientId: row.original.id,
            }),
    },
];