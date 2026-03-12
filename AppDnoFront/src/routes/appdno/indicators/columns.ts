import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table/index.js";
import DataTableButton from "./data-table-button.svelte";

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
            renderComponent(DataTableButton, {
                indicatorId: row.original.id,
            }),
    },
];
