import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table/index.js";
import DataTableButton from "./data-table-button.svelte";

export type Indicator = {
    id: number;
    name: string;
};

export const columns: ColumnDef<Indicator>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                indicatorId: row.original.id,
            }),
    },
];
