import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

export type Ingredient = {
    id: number;
    name: string;
    supplierId: number;
    projectsNumber: number;
};

export const columns: ColumnDef<Ingredient>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        accessorKey: "supplierId",
        header: "ID Fournisseur",
    },
    {
        accessorKey: "projectsNumber",
        header: "Nombre de projets",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(ArrowNavButton, {
                route: `/appdno/ingredients/${row.original.id}`,
            }),
    },
];
