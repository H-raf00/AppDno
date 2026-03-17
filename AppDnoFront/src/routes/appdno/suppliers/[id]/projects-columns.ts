import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

export type Ingredient = {
    id: number;
    name: string;
};

export const columns: ColumnDef<Ingredient>[] = [
    {
        accessorKey: "name",
        header: "Liste des ingrédients",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(ArrowNavButton, {
                route: `/appdno/ingredients/${row.original.id}`,
            }),
    },
];
