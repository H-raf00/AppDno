import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { DataTableButton } from "$lib/components/ui/data-table-button";

export type Client = {
    id : number;
    name: string;
    projectsNumber: number;
};

export const columns: ColumnDef<Client>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        accessorKey: "projectsNumber",
        header: "Nombre de projets",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                route: `/appdno/clients/${row.original.id}`,
            }),
    },
];