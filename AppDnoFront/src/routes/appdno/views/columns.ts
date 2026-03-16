import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

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
            renderComponent(ArrowNavButton, {
                route: `/appdno/views/${row.original.id}`,
            }),
    },
];
