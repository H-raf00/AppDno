import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

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
            renderComponent(ArrowNavButton, {
                route: `/appdno/clients/${row.original.id}`,
            }),
    },
];