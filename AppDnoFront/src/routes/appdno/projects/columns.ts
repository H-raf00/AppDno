import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

export type Project = {
    id: number;
    code: string;
    name: string;
    responsableId: number;
    clientId: number;
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
        accessorKey: "responsableId",
        header: "Responsable Id",
    },
    {
        accessorKey: "clientId",
        header: "Client Id",
    },
    {
        accessorKey: "ingredientsNumber",
        header: "Nombre d'ingrédients",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(ArrowNavButton, {
                route: `/appdno/projects/${row.original.id}`,
            }),
    },
];
