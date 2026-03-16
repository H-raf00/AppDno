import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

export type Indicator = {
    id: number;
    name: string;
    description: string;
    type: string;
};

export const columns: ColumnDef<Indicator>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        accessorKey: "description",
        header: "Description",
    },
    {
        accessorKey: "type",
        header: "Type",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(ArrowNavButton, {
                route: `/appdno/indicators/${row.original.id}`,
            }),
    },
];
