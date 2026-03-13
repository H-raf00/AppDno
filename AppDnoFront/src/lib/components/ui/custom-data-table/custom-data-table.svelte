<script lang="ts" generics="TData, TValue">
    import { type ColumnDef } from "@tanstack/table-core";
    import { DataTable } from "$lib/components/ui/data-table";

    type DataTableProps<TData, TValue> = {
        columns: ColumnDef<TData, TValue>[];
        data: TData[];
    };

    let { data, columns }: DataTableProps<TData, TValue> = $props();
</script>

<DataTable {data} {columns} />
