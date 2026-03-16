import type { ColumnDef } from "@tanstack/table-core";
import { renderComponent } from "$lib/components/ui/data-table";
import { ArrowNavButton } from "$lib/components/ui/arrow-nav-button";

export type Project = {
    id: number;
    name: string;
};

export const columns: ColumnDef<Project>[] = [
    {
        accessorKey: "name",
        header: "Nom des projets",
    },
    {
        id: "actions",
        cell: ({ row }) =>
            renderComponent(ArrowNavButton, {
                route: `/appdno/projects/${row.original.id}`,
            }),
    },
];
