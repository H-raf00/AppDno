import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table/index.js";
import DataTableButton from "./data-table-button.svelte";

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
            renderComponent(DataTableButton, {
                supplierId: row.original.id,
            }),
    },
];