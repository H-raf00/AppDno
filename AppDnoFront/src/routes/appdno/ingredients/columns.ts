import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { DataTableButton } from "$lib/components/ui/data-table-button";

export type Ingredient = {
    id: number;
    name: string;
    supplierId: number;
    supplierName: string;
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
            renderComponent(DataTableButton, {
                route: `/appdno/ingredients/${row.original.id}`,
            }),
    },
];
