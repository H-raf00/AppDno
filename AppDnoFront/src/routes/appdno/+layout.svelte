<script lang="ts">
    import { Button } from "$lib/components/ui/button/index.js";
    import { goto } from "$app/navigation";
    import { page } from "$app/state";

    let { children } = $props();

    let selectedMenu = $state("tableau-de-bord");

    const menuItems = [
        { id: "tableau-de-bord", label: "Tableau de bord", href: "/appdno" },
        { id: "utilisateurs", label: "Utilisateurs", href: "/appdno/users" },
        { id: "clients", label: "Clients", href: "/appdno/clients" },
        { id: "projets", label: "Projets Clients", href: "/appdno/projects" },
        { id: "fournisseurs", label: "Fournisseurs d'ingrédients", href: "/appdno/suppliers" },
        { id: "ingredients", label: "Base d'ingrédients", href: "/appdno/ingredients" },
        { id: "ingredients-valider", label: "Ingrédients à valider", href: "/appdno/ingredients/pending" },
        { id: "indicateurs", label: "Base d'indicateurs", href: "/appdno/indicators" },
    ];

    $effect(() => {
        const currentPath = page.url.pathname;
        const item = menuItems.find(m => m.href === currentPath);
        if (item) {
            selectedMenu = item.id;
        }
    });
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
                <div class="">
                    <div class="flex border-b-2 border-gray-300">
                        {#each menuItems as item}
                            <button
                                class={`pb-2 px-4 border-b-2 transition-colors ${
                                    selectedMenu === item.id
                                        ? "border-red-500"
                                        : "border-transparent"
                                }`}
                                onclick={() => {
                                    selectedMenu = item.id;
                                    goto(item.href);
                                }}
                            >
                                {item.label}
                            </button>
                        {/each}
                    </div>
                </div>
                <!-- main content -->
                <div>
                    {@render children()}
                </div>
            </div>
        </div>
    </main>
</div>
