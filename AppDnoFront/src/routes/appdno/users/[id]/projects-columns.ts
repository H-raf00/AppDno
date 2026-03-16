import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { DataTableButton } from "$lib/components/ui/data-table-button";

export type Project = {
    id: number;
    name: string;
};

export const columns: ColumnDef<Project>[] = [
    {
        accessorKey: "name",
        header: "Nom",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(DataTableButton, {
                route: `/appdno/projects/${row.original.id}`,
            }),
    },
];
