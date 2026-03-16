import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { DataTableButton } from "$lib/components/ui/data-table-button";

export type PendingIngredient = {
    id: number;
    name: string;
    supplierId: number;
};

export const columns: ColumnDef<PendingIngredient>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        accessorKey: "supplierId",
        header: "ID Fournisseur",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                route: `/appdno/ingredients/${row.original.id}`,
            }),
    },
];
