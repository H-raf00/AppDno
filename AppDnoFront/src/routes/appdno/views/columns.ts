import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { DataTableButton } from "$lib/components/ui/data-table-button";

// what is a view?
export type View = {
    id: number;
    name: string;
};

export const columns: ColumnDef<View>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                route: `/appdno/views/${row.original.id}`,
            }),
    },
];
