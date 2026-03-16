import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

export type Supplier = {
    id : number;
    name: string;
    ingredientsNumber: number;
};

export const columns: ColumnDef<Supplier>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        accessorKey: "ingredientsNumber",
        header: "Nombre d'ingrédients",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(ArrowNavButton, {
                route: `/appdno/suppliers/${row.original.id}`,
            }),
    },
];