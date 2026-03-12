<script lang="ts">
    import { Button } from "$lib/components/ui/button/index.js";
    let { children } = $props();
</script>

<div class="flex h-screen">
    <!-- Sidebar -->
    <aside
        class="w-16 bg-white border-r border-gray-100 flex flex-col items-center py-4"
    >
        <!-- Logo -->
        <div class="mb-6">
            <div
                class="w-10 h-10 rounded-xl bg-linear-to-br from-orange-400 via-pink-500 to-purple-600 flex items-center justify-center"
            >
                icon
            </div>
        </div>

        <!-- Navigation Icons -->
        <nav class="flex-1 flex flex-col items-center gap-2">
            <Button
                class="w-10 h-10 flex items-center justify-center text-gray-400 hover:bg-gray-50 rounded-lg transition-colors"
                >ici
            </Button>
        </nav>
    </aside>

    <!-- Main Content -->
    <main class="flex-1 flex flex-col">
        <!-- Top Header -->
        <header
            class="h-14 border-b border-gray-100 flex items-center justify-between px-6"
        ></header>

        <!-- Page Content -->
        <div class="flex-1 p-6">
            <!-- Page Title -->
            <div class="flex items-center gap-3 mb-6">
                <h1 class="text-2xl font-semibold text-gray-900">AppDno</h1>
            </div>

            <!-- Content Area -->
            <div class="flex-1">
                <!-- top bar -->
                <div></div>
                <!-- main content -->
                <div>
                    {@render children()}
                </div>
            </div>
        </div>
    </main>
</div>
